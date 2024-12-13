// ajax.js

function fetchRandomTodo() {
    $.ajax({
        url: 'https://jsonplaceholder.typicode.com/posts', 
        method: 'GET',
        success: function(response) {
            // Choose a random post from the API response
            // floor means int val(round off)
            // random means random number
            const randomPost = response[Math.floor(Math.random() * response.length)];

            // Set the title and description in the input fields
            $('#todoTitle').val(randomPost.title);
            $('#todoDescription').val(randomPost.body);
        },
        error: function(xhr, status, error) {
            console.error('Error fetching data:', error);
            alert('Failed to fetch data from the API. Please try again.');
        }
    });
}

// Expose fetchRandomTodo globally
window.fetchRandomTodo = fetchRandomTodo;
