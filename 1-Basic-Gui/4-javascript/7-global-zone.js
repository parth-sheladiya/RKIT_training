// global scope 
const firstNumber = '15';

console.log(firstNumber);

{
    console.log(firstNumber)
}

if(true){
    console.log(firstNumber)
}
console.log(150)

// for(let i=0;i<2;i++){
//     console.log(firstNumber)
// }

function createFirstFunction(){
    console.log("execute first function ",firstNumber)
}
createFirstFunction();



// function scope 

// console.log(fullName);
function createFunctionScope(){
    const fullName = "parth";
    console.log("hello  dunia");
    console.log(fullName);
}

// console.log(fullName);
createFunctionScope();


// bloack scope
// var is access outside of block

console.log(firstBlockScopeValue)
{
    var firstBlockScopeValue = 10;
}
console.log(firstBlockScopeValue)


{
    let secondBlockScopeValue = 20;
    console.log(secondBlockScopeValue)
}
// console.log(secondBlockScopeValue)

{
    const secondBlockScopeValue = 200;
    console.log(secondBlockScopeValue)
}
// console.log(secondBlockScopeValue)