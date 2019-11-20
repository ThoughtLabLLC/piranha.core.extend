"use strict";

const patterns = {
    css: /\.css$/,
    js: /\.js$/,
    scss: /\.scss$/,
    ts: /\.ts$/,
};

module.exports = {
    patterns: patterns,

    paths: {
        wwwroot: "wwwroot"
    },

    renameScssToCss: function (filename) {
        return filename.replace(patterns.scss, ".css");
    },
    renameTsToJs: function (filename) {
        return filename.replace(patterns.ts, ".js");
    },

    generateMinifiedFileName: function (filename) {
        const extension = filename.substring(filename.lastIndexOf('.'), filename.length) || filename;
        const pattern = new RegExp(`${extension.replace(/[-\/\\^$*+?.()|[\]{}]/g, "\\$&")}$`);

        return filename.replace(pattern, `.min${extension}`);
    }
};