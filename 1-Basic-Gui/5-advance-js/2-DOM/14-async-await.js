async function getData(){
    setTimeout(function(){
        console.log("i am  inside set time  out")
    },3000)
}

getData();


// fetch api

async function firstGetApiData(){
    // get request 
    let responce = await fetch('https://jsonplaceholder.typicode.com/posts/')
    // convert to json object
    let data = await responce.json();
    console.log(data)
}

firstGetApiData();


async function firstGetData(){
    let url ='https://jsonplaceholder.typicode.com/todos/1';

    try{
        let responce = await fetch(url);
        if(!responce){
            console.log("data not fetch");
        }
        let convertJson = await responce.json();
        console.log(convertJson);
    }
    catch(error){
        console.log(error);

    }   
}
setTimeout(firstGetData, 5000);


const myHeaders = new Headers();
myHeaders.append("Content-Type", "application/json");

const url = "https://jsonplaceholder.typicode.com/posts";

const options = {
    method: "POST",
    body: JSON.stringify({ username: "parth sheladiya" }),
    headers: myHeaders,
};

async function getResponceData() {
    try {
        const response = await fetch(url, options); 
        const data = await response.json(); 
        console.log("my data", data); 
    } catch (error) {
        console.error("Error:", error); 
    }
}

getResponceData();
