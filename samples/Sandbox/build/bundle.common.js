"use strict";

const bundles = require("../bundles.json");

function getBundles(regex) {
    return bundles.filter(function (bundle) {
        return regex.test(bundle.outputFileName);
    });
}

function getFilesToCompile(regex) {
    const files = [];

    for (let bundle of bundles) {        
        files.push(...bundle.inputFiles.filter(function (file) {
            return regex.test(file);
        }))
    }

    return files;
}

module.exports = {
    get all() {
        return bundles;
    },
    match: getBundles,
    getFilesToCompile: getFilesToCompile
};