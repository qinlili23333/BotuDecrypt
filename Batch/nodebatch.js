console.log("Project Codename: Aya");
console.log("Qinlili 2022");
const fs = require('fs');
const path = require("path");
const timelog = text => { console.log(new Date().toLocaleTimeString() + "  -  " + text) };
// 检测文件名是否合法，不包含：\/：*？“<>|
function CheckFileName(path) {
    if (path == null)
        return false;
    for (var i = path.length - 1; i >= 0; i--) {
        if (path.charAt(i) == '\\' || path.charAt(i) == '/' || path.charAt(i) == ':' || path.charAt(i) == '*'
            || path.charAt(i) == '?' || path.charAt(i) == '\"' || path.charAt(i) == '<' || path.charAt(i) == '>'
            || path.charAt(i) == '|') {
            return false;
        }

    }
    return true;
}

// 去除文件名中不合法的部分
function HandleFileName(path) {
    if (path == null)
        return "";
    var buffer = ""
    for (var i = 0; i < path.length; i++) {
        if (path.charAt(i) == '\\' || path.charAt(i) == '/' || path.charAt(i) == ':' || path.charAt(i) == '*'
            || path.charAt(i) == '?' || path.charAt(i) == '\"' || path.charAt(i) == '<' || path.charAt(i) == '>'
            || path.charAt(i) == '|') {

        } else {
            buffer += (path.charAt(i));
        }

    }
    return buffer;
}
if (process.argv[2]) {
    timelog("JSON path:" + process.argv[2]);
} else {
    console.error("ERROR:No Path Provided!");
    process.exit()
};
timelog("Reading JSON...")
let rawdata = fs.readFileSync(process.argv[2]);
timelog("JSON size:" + rawdata.length);
timelog("Parsing JSON...");
let pdfList = JSON.parse(rawdata);
timelog("Parse Success, " + pdfList.length + " Files Found.");
const execSync = require("child_process").execSync;
let errorList = [];
for (let i = 0; pdfList[i]; i++) {
    console.log(pdfList[i]);
    if (fs.existsSync("output/" + HandleFileName(pdfList[i].name) + ".pdf")) {
        console.log("Skip Exist")
    } else {
        execSync('BotuDecrypt.exe \"' + pdfList[i].url + '\" \"' + HandleFileName(pdfList[i].name) + '\"');
    }
}