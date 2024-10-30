let car={
    color:"red",
    model:2021,
    brand:"innova",

    drive:function(){
        console.log("driving car")
    }
};

car.drive();
console.log(car.model);
console.log(car.brand);

class Introduction{
    constructor(fName,age){
        this.fName=fName;
        this.age=age;
    }
    details(){
        console.log(`hello everyone my name is ${this.fName} and my age is ${this.age}`);
    }
}

const intro = new Introduction("ravi",21);
intro.details();


const person ={fName:"parth",lName:"sheladiya",age:20};
const person2 ={
    fName:"parth",
    lName:"sheladiya",
    age:20
};
const person3 ={};
person3.fName="parth";
person3.lName="sheladiya";
person3.age="20";

const person4 = new Object();
person4.fName="parth";
person4.lName="sheladiya";
person4.age="20";


const myObj = {
    a:20,
    b:20,
    myInnerObj:{
        c:30,
        d:40,
    }
}

console.log(myObj.myInnerObj.c);

const person5 = {
    fName:"parth",
    id:101,
    detailOfPerson5 : function(){
        return  this.fName + " " + this.id;
    }
}

console.log(person5.detailOfPerson5());
console.log(person5.fName);
console.log(person5);

console.log(person5.detailOfPerson5);


class Person {
    constructor(name, age) {
        this.name = name; 
        this.age = age;    
    }
}

const personOne = new Person("Parth", 25);  
const personTwo = new Person("Ravi",24);
console.log(personOne.name);  
console.log(personOne.age);  
console.log(personTwo.name);  
console.log(personTwo.age);  


function Ctor(fName, lName, age) {
    this.fName = fName;
    this.lName = lName;
    this.age = age;
}


Ctor.prototype.course = "CSE";

const person6 = new Ctor("Parth", "Sheladiya", 20);


console.log(person6.course);


// // get or set 

const CarSpeed ={
    speed:30,

    get currentSpeed(){
        return this.speed;
    },
    set currentSpeed(speedValue){
        if(speedValue>100){
            console.log('pleade drivve slow ');
            return this.speed = 100;
        }
        else{
            console.log("medium drive speed")
            this.speed=speedValue;
        }
    }
}

console.log(CarSpeed.currentSpeed);

CarSpeed.currentSpeed =300;
console.log(CarSpeed.currentSpeed);

CarSpeed.currentSpeed=50;
console.log(CarSpeed.currentSpeed);


