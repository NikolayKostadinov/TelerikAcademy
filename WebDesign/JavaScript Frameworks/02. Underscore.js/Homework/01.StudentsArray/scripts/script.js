/// <reference path="classical-oop.js" />
/// <reference path="underscore.js" />
//Write a method that from a given array of students 
//finds all students whose first name is before its last name alphabetically. 
//Print the students in descending order by full name. Use Underscore.js


(function () {

    var student = Class.create({
        init: function (firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            var that = this;
        },
        getFullName: function () {
            return this.firstName + " " + this.lastName;
        }

    });

    var students = [new student("Nikolay", "Kostadinov"),
        new student("Ilina", "Kostadinova"),
        new student("Hristo", "Grigorov"),
        new student("Svilen", "Boshnakov"),
        new student("Detelin", "Yolov"),
        new student("Kosta", "Kiryazov"),
    ];



    function findStudets(students) {
        _.chain(students)
            .filter(function (item) {
                return item.firstName.toString() < item.lastName.toString();
            })
            .sortBy("getFullName()")
            .each(function (item) {
                console.log(item.getFullName());
            });
    }

    findStudets(students);
})()
