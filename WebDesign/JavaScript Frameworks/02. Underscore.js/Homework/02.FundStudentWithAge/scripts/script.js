/// <reference path="classical-oop.js" />
/// <reference path="underscore.js" />
//  Write function that finds the 
// Write function that first name and last name of all students with 
// age between 18 and 24. Use Underscore.js



(function () {

    var student = Class.create({
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            var that = this;
        },
        toString: function () {
            return this.firstName + " " + this.lastName + " " + this.age;
        }

    });

    var students = [
        new student("Nikolay", "Kostadinov", 10),
        new student("Ilina", "Kostadinova", 20),
        new student("Hristo", "Grigorov", 18),
        new student("Svilen", "Boshnakov", 23),
        new student("Detelin", "Yolov", 24),
        new student("Kosta", "Kiryazov", 50),
    ];

    function findStudets(students) {
        _.chain(students)
            .filter(function (item) {
                return item.age >= 18 && item.age <= 24;
            })
            .sortBy("age")
            .each(function (item) {
                console.log(item.toString());
            });
    }

    findStudets(students);
})()
