// ==UserScript==
// @name         Botu Batch Downloader V2
// @namespace    https://qinlili.bid
// @version      0.1
// @description  批量抓取博图原始文件，非南中医远程访问自己改适配地址
// @author       琴梨梨
// @match        https://webvpn.njucm.edu.cn/http/webvpnd7aec0ab7095a62bc04960cec7788f5b453a3cf4b7ada805a1fdbb8f1cfe985b/*
// @grant        none
// ==/UserScript==

(async function () {
    'use strict';
    window.launch = () => {
        let startNum = localStorage.lastSuccess ? (Number(localStorage.lastSuccess) + 1) : 0;
        let pdfArray = [];
        let grab = async num => {
            console.log("Processing Book " + num);
            let webPage = await (await fetch("https://webvpn.njucm.edu.cn/http/webvpnd7aec0ab7095a62bc04960cec7788f5b453a3cf4b7ada805a1fdbb8f1cfe985b/CheckIpForRead.aspx?bookid=" + num)).text();
            let webDom = new DOMParser().parseFromString(webPage, "text/html");
            console.debug(webDom);
            let pdfUrl = webDom.body.getAttribute("onload").split("'")[3];
            console.debug((pdfUrl == "") ? "Cannot Access. Skip." : pdfUrl);
            let pdfObj = {
                name: webDom.title,
                url: (pdfUrl == "") ? null : pdfUrl,
                success: (pdfUrl == "") ? false : true,
                filename: pdfUrl.substr(pdfUrl.lastIndexOf("/") + 1),
                link: "/CheckIpForRead.aspx?bookid=" + num
            }
            console.debug(pdfObj);
            pdfArray.push(pdfObj);
            if (pdfArray.length > 999) {
                dlFile(URL.createObjectURL(new Blob([JSON.stringify(pdfArray)])), Date.now() + ".json");
                pdfArray = [];
                localStorage.lastSuccess = num;
                console.log("Saved Progress:" + num);
            };
            return grab(num + 1);
        };
        grab(startNum);
    }

    const sleep = delay => new Promise(resolve => setTimeout(resolve, delay));
    const dlFile = (link, name) => {
        let eleLink = document.createElement('a');
        eleLink.download = name;
        eleLink.style.display = 'none';
        eleLink.href = link;
        document.body.appendChild(eleLink);
        eleLink.click();
        document.body.removeChild(eleLink);
    };
})();