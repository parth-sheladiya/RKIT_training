 


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