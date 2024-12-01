async function firstGetApiData(){
    // sent req 
    let responce = await fetch('https://jsonplaceholder.typicode.com/posts/')
    console.log(responce)
    
    // json 
    let data = await responce.json();
    console.log(data)
}

firstGetApiData();



