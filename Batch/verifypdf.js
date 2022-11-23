const fs = require('fs');
const path = require("path");
console.log("Initialize...");
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
arr.forEach(item => {
    if (item.endsWith(".pdf")) {
        let fullpath = path.join(process.argv[2], item);
        let fd = fs.openSync(fullpath, 'r');
        let buffer = Buffer.alloc(8);
        fs.readSync(fd, buffer, 0, 3, 5);
        let version = buffer.toString();
        if (parseFloat(version) == 1.7) {
            //console.log("Verify Success: " + fullpath + " -1.7");
        } else {
            console.log("Verify Fail: " + fullpath + " -" + version);
            fs.rename(fullpath, process.argv[2] + "/../" + item, function (err) {
                if (err) {
                    throw err;
                }
            })
        }
    }
});