"use strict";

const gulp = require("gulp");
const bundles = require("../bundle.common");
const common = require("../common");

gulp.task("watch", function () {
    for (const jsBundle of bundles.match(common.patterns.js)) {
        gulp.watch(jsBundle.inputFiles, ["bundle:js"]);
    }

    for (const cssBundle of bundles.match(common.patterns.css)) {
        gulp.watch(cssBundle.inputFiles, ["bundle:css"]);
    }

    for (const scssBundle of bundles.getFilesToCompile(common.patterns.scss)) {
        gulp.watch(scssBundle.inputFiles, ["bundle:css"]);
    }

    for (const tsBundle of bundles.getFilesToCompile(common.patterns.ts)) {
        gulp.watch(tsBundle.inputFiles, ["bundle:js"]);
    }

    gulp.watch("styles/bootstrap-overrides/*.scss", ["bundle:css"]);

    gulp.watch("images", ["optimize:images"]);
});