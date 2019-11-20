"use strict";

const gulp = require("gulp");
const del = require("del");
const bundles = require("../bundle.common");
const common = require("../common");

gulp.task("clean:bundles", function () {
    const files = [];

    for (const bundle of bundles.all) {
        files.push(common.paths.wwwroot + "/" + bundle.outputFileName, common.generateMinifiedFileName(common.paths.wwwroot + "/" + bundle.outputFileName));
    }

    return del(files);
});

gulp.task("clean:compilier", function () {
    return del([
        ...bundles.getFilesToCompile(common.patterns.scss).map(common.renameScssToCss),
        ...bundles.getFilesToCompile(common.patterns.ts).map(common.renameTsToJs)
    ]);
});

gulp.task("clean:images", function () {
    return del(common.paths.wwwroot + "/images");
});

gulp.task("clean", ["clean:bundles", "clean:compilier", "clean:images"]);