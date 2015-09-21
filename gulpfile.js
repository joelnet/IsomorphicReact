var gulp = require("gulp"),
    react = require("gulp-react");

var paths = {
    jsx: "./Scripts/**/*.jsx",
    jsDestination: "./Scripts"
};

gulp.task("jsx", function () {
    return gulp.src(paths.jsx)
        .pipe(react())
        .pipe(gulp.dest(paths.jsDestination));
});