
// basic class
// class human {
//     // state or property 
//     age=13;
//     weight=120;
//     height=140;


//     // behaviour or functin 
//     walking(){
//         console.log("walking");
//     }
//     talking(){
//         console.log("talking");
//     }
// }

// let objFirst = new human();
// console.log(objFirst.age)
// console.log(objFirst.weight)
// console.log(objFirst.height)
// objFirst.walking();
// objFirst.talking();


// private property inside class

// class human {
//     // state or property 
//     age=13;
//     #weight=120;
//     height=140;


//     // behaviour or functin 
//     walking(){
//         console.log("walking" , this.#weight);
//     }
//     talking(){
//         console.log("talking");
//     }
// }

// let objFirst = new human();
// console.log(objFirst.age)
// console.log(objFirst.weight)
// console.log(objFirst.height)
// objFirst.walking();
// objFirst.talking();


// private property outside class this used a get set

// class human{
//     // properrty or state
//     age=10;
//     height=160;
//     #weight=40;


//     // behaviour or function 

//     walking(){
//         console.log("walking")
//     }
//     talking(){
//         console.log("talking")
//     }

//     get fetchWeight(){
//         return this.#weight;
//     }

//     set modifyWeight(value){
//         this.#weight = value;
//     }
// }

// let secondObj = new human();
// console.log(secondObj.age);
// console.log(secondObj.height);
// console.log(secondObj.fetchWeight)



// default parameter 


function firstFunction(myName="parth" , myCarName = "bmw"){
    console.log("hello javascript" ,myName , myCarName);
}
firstFunction();

// null property
function secondFunction(myName="parth"){
    console.log("hello javascript" ,myName);
}
secondFunction(null);

// undefined
function thirdFunction(myName="parth"){
    console.log("hello javascript" ,myName);
}
thirdFunction(undefined);

// nuilt in function
function fourthFunction(myName="parth" , myCarName = myName.toUpperCase()){
    console.log("hello javascript" ,myName , myCarName);
}
fourthFunction("ravi" , "innova");

// object property
function fifthFunction(obj={age:20, height:130}){
    console.log("hello javascript" ,obj);
}
fifthFunction({age:30 ,height:122});

// array property in default parameter
function sixFunction(arr=['parth' ,'python' , 'javascript']){
    console.log("hellp javascript" , arr)
}
sixFunction(['raj','raju'])

// 

function getAge(){
    return 20;
}
function Myname(){
    return "patel"
}
function sevenFunction(myName = Myname() , myAge=getAge())
{
    console.log("hello javascript", myName , myAge);

}
sevenFunction();