// const cache ={};

// function fetchDataFromCache(key){
//     if(cache[key]){
//         console.log("data is available in cache");
//         console.log(cache[key]);
//         return cache[key];
//     }else{
//         console.log("data fatching from source");
//         const data = `data for ${key}`;

//         // data store in cache
//         cache[key] = data;
//         console.log(data);
//         return data;
//     }
// }


// console.log(fetchDataFromCache("cache1"));
// console.log(fetchDataFromCache("cache1"));
// console.log(fetchDataFromCache("cache2"));
// console.log(fetchDataFromCache("cache3"));



const cacheApi={};

async function fetchApiFromResourceOrCache(url){
    if(cacheApi[url]){
        console.log("url data available in cache");
        // console.log(cacheApi[url]);
        return cacheApi[url];
    }
    else{
        console.log("fatching url data from source");

        try{
            const responceForUrl = await fetch(url);
            const data = await responceForUrl.json();

            cacheApi[url] = data;
            console.log("data store in cache",url);
            return data;
            
        }catch(error){
            console.log("error fatching  data" , error);
        }
    }
}

fetchApiFromResourceOrCache("https://jsonplaceholder.typicode.com/posts/1").then(console.log)
// fetchApiFromResourceOrCache("https://jsonplaceholder.typicode.com/posts/1").then(console.log)