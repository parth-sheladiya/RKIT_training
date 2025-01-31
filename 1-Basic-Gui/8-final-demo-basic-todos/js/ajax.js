// ajax.js

function fetchRandomTodo() {
    $.ajax({
        url: 'https://jsonplaceholder.typicode.com/posts', 
        method: 'GET',
        success: function(response) {
            // Choose a random post from the API response
            // floor means int val(round off)
            
            const randomIndex = Math.floor(Math.random() * response.length);
            const randomPost = response[randomIndex];
            // Set the title and description in the input fields
            $('#todoTitle').val(randomPost.title);
            $('#todoDescription').val(randomPost.body);
        },
        error: function(xhr, status, error) {
            console.error('error in faching data', error);
            alert('failed to fetch data');
        }
    });
}

// Expose fetchRandomTodo globally
window.fetchRandomTodo = fetchRandomTodo;
