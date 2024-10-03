// function define 
function setMyName(){
    console.log('my name is parth')
}
// funnction call 
setMyName()


function printCount(){
    for(let i=0;i<100;i++){
        console.log(i);
    }
}
printCount();

// function with parameter
function labelPrint(num){
    console.log("print number" ,num);
}
// function call with argument
labelPrint(10);


// return function
function getSum(firstNum , secondNum , thirdNum){
    let sum = firstNum + secondNum + thirdNum;
    return sum;
}
let finalAns =getSum(10,20,30);
console.log("answer" , finalAns);

// function store in variable arry

let getName = function (firstName , lastName){
    let fullName = firstName + lastName;
    return fullName;
}
console.log(getName('5','5'))


// arrow function 

const squareOfTwoNum =  (firstNum , secondNum) => {
    let ans = firstNum ** secondNum;
    return ans;
}

console.log(squareOfTwoNum(5,5));


// basic validation
if(username==""){
    alert("username is required")
}
else if(email==""){
    alert("email is required")
}
else if(password==""){
    alert("password is required")
}

// basic validation in function
if(isValidNumber(userNumber)){
    console.log("valid number")
}
else{
    alert("please enter valid number")
}
