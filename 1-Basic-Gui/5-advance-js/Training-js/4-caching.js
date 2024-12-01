const cache ={};

function fetchDataFromCache(key){
    if(cache[key]){
        console.log("data is available in cache");
        // console.log(cache[key]);
        return cache[key];
    }else{
        console.log("data fatching from source");
        const data = `data for ${key}`;

        // data store in cache
        cache[key] = data;
        // console.log(data);
        return data;
    }
}


console.log(fetchDataFromCache("cache1"));
console.log(fetchDataFromCache("cache1"));
console.log(fetchDataFromCache("cache2"));
console.log(fetchDataFromCache("cache3"));
console.log(fetchDataFromCache("cache2"));



