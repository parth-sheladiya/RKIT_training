let obj = {
    newNum:10,
    oldNum:20,
}
console.log(obj)

obj.midNum=50;

console.log(obj);

// 1 spread operator 

let firstObj1 = {
    fName:'parth',
    lName:'sheladiya'
}
let firstObj2 = {...firstObj1};
firstObj1.fName='Ravi'

console.log(firstObj1)
console.log(firstObj2)

// 2 assign  method 

let secondObj1 ={
    ft:1,
    wt:12,
    ht:130
}

let secondExtraObj = {
    fName:'travels',
    lName:'raj'
}

let secondObj2= Object.assign({} ,secondObj1 ,secondExtraObj);

secondObj1.ft=122;

console.log(secondObj1);
console.log(secondObj2);


// 3 itration method

let thirdObj1 ={
    a:10,
    b:20,
}

let thirdObj2={};


for(let key in thirdObj1) {
    let newKey = key;
    let newValue = thirdObj1[key];

    thirdObj2[newKey]=newValue;
}

console.log(thirdObj1);
console.log(thirdObj2);