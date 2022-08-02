// ==UserScript==
// @name         Botu Batch Downloader
// @namespace    https://qinlili.bid
// @version      0.1
// @description  批量抓取博图原始文件，非南中医远程访问自己改适配地址
// @author       琴梨梨
// @match        https://webvpn.njucm.edu.cn/http/webvpnd7aec0ab7095a62bc04960cec7788f5b453a3cf4b7ada805a1fdbb8f1cfe985b/TOP*
// @match        https://webvpn.njucm.edu.cn/http/webvpnd7aec0ab7095a62bc04960cec7788f5b453a3cf4b7ada805a1fdbb8f1cfe985b/GenericErrorPage.htm?aspxerrorpath=/TOP.aspx
// @grant        none
// ==/UserScript==

(async function() {
    'use strict';
    if(document.location.search==""){
        location.replace(document.location.href+"?page=0");
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
    console.log("Process Current Page...");
    let T3Array=document.getElementsByClassName("T3");
    if(T3Array.length==0){
        console.log("Sleep 30s To Prevent Overload.");
        await sleep(30000);
        location.href= localStorage.goUrl;
        return;
    };
    let urlArray=[];
    [].forEach.call(T3Array,element=>{
        urlArray.push(element.getElementsByTagName("a")[0].href);
    });
    console.log(urlArray);
    let pdfArray=[];
    for(let i=0;urlArray[i];i++){
        console.log("Processing Book "+i);
        let webPage=await (await fetch(urlArray[i])).text();
        let webDom=new DOMParser().parseFromString(webPage, "text/html");
        console.log(webDom);
        let pdfUrl=webDom.body.getAttribute("onload").split("'")[3];
        console.log(pdfUrl);
        pdfArray.push({
            name:T3Array[i].parentElement.getElementsByTagName("div")[0].getElementsByTagName("b")[0].innerText.replace("《","").replace("》",""),
            url:pdfUrl,
            filename:pdfUrl.substr(pdfUrl.lastIndexOf("/")+1)
        })
    }
    console.log(pdfArray);
    console.log("Save To LocalStorage...");
    if(!localStorage.savedFile){
        localStorage.savedFile="[]"
    };
    let savedFile=JSON.parse(localStorage.savedFile);
    pdfArray.forEach(pdf=>{
        savedFile.push(pdf);
    });
    if(savedFile.length>1000){
        dlFile(URL.createObjectURL(new Blob([JSON.stringify(savedFile)])),Date.now()+".json");
        savedFile=[];
    };
    localStorage.savedFile=JSON.stringify(savedFile);
    console.log("To Next Page");
    let search=new URLSearchParams(location.search);
    let currentPage=search.get("page");
    localStorage.savedPage=currentPage;
    localStorage.goUrl="https://webvpn.njucm.edu.cn/http/webvpnd7aec0ab7095a62bc04960cec7788f5b453a3cf4b7ada805a1fdbb8f1cfe985b/TOP.aspx?page="+(Number(currentPage)+1);
    location.href="https://webvpn.njucm.edu.cn/http/webvpnd7aec0ab7095a62bc04960cec7788f5b453a3cf4b7ada805a1fdbb8f1cfe985b/TOP.aspx?page="+(Number(currentPage)+1);
})();