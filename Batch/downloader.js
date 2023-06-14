const fs = require('fs');
const readline = require('readline');
const path = require("path");
const events = require('events');
const http = require('http');
console.log("Initialize...");
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
    buffer = buffer.replace(/[^\x00-\x7F]/g, "");
    if (buffer == "") { buffer = Date.now() }
    return buffer;
}
if (process.argv[2]) {
    console.log("Folder path:" + process.argv[2]);
} else {
    console.error("ERROR:No Path Provided!");
    process.exit()
};
if (!fs.existsSync(process.argv[2])) {
    console.error("ERROR:Path Invalid!");
    process.exit()
};
let arr = fs.readdirSync(process.argv[2]);
console.log(arr.length);
let fileList = [];
(async () => {
    for (const item of arr) {
        if (item.endsWith(".log")) {
            let fullpath = path.join(process.argv[2], item);
            var readObj = readline.createInterface({
                input: fs.createReadStream(fullpath)
            });
            readObj.on('line', function (line) {
                readObj.close();
                let file = line.split("+");
                fileList.push({ name: HandleFileName(file[2]), path: file[1] });
            });
            await events.once(readObj, 'close');
        }
    };
    console.log(fileList);
    for (const file of fileList) {
        let file1 = false;
        if (fs.existsSync(process.argv[2] + "\\..\\Download\\" + file.name + ".pdf")) {
            console.log("Skip Exist")
        } else {
            const promise1 = new Promise((resolve, reject) => {
                http.get(file.path, (res) => {
                    // Open file in local filesystem
                    file1 = fs.createWriteStream(process.argv[2] + "\\..\\Download\\" + file.name + ".pdf");
                    // Write data into local file
                    res.pipe(file1);
                    // Close the file
                    file1.on('finish', () => {
                        file1.close();
                        console.log(file.name + ` File downloaded!`);
                        resolve();
                    });
                }).on("error", (err) => {
                    console.log("Error: ", err.message);
                    fs.unlinkSync(process.argv[2] + "\\..\\Download\\" + file.name + ".pdf");
                    reject();
                });
            });
            await promise1;
        }
    }
})()