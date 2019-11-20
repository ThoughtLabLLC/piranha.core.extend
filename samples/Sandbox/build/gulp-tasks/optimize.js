"use strict";

const gulp = require("gulp");
const imagemin = require("gulp-imagemin");
const common = require("../common");

gulp.task("optimize:images", function () {
    return gulp
        .src("images/**/*", { base: "." })
        .pipe(imagemin([
            imagemin.svgo({
                plugins: [
					{
						convertShapeToPath: false,
						removeViewBox: false
					}
                ]
            })
        ]))
        .pipe(gulp.dest(common.paths.wwwroot));
});

gulp.task("optimize", ["optimize:images"]);