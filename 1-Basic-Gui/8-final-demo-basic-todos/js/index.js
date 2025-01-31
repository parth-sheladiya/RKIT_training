class TodoApp {
  static UserDataKey = "user_"; 
  static TodoDataKey = "todos_";

  constructor() {
    this.loggedInEmail = localStorage.getItem("loggedInEmail");
    this.usernameElement = $("#username");
    this.todoListElement = $("#todoList");
    this.titleInput = $("#todoTitle");
    this.descriptionInput = $("#todoDescription");
    this.searchInput = $("#searchTodo");

    this.checkLogin();
    this.initEventHandlers();
    this.renderTodos();
  }

  // Check if the user is logged in
  checkLogin() {
    if (!this.loggedInEmail) {

      window.location.href = "login.html";
      // redirectTo("index.html")
    } else {
      // get todo data if user is alerady login
      const userData = JSON.parse(
        localStorage.getItem(TodoApp.UserDataKey+ this.loggedInEmail)
      );
      this.usernameElement.text(userData.firstName + " " + userData.lastName);
    }
  }

  // all event haldlers based on todo functionality 
  initEventHandlers() {
    // all function call with click event is call call back function
    $("#addTodo").click(() => this.addTodo());
    // auto generate 
    $("#generateTodos").click(() => this.generateTodo());
    // logout key
    $("#logout").click(() => this.logout());
    // Search button click
    $("#searchButton").click(() => this.searchTodos()); 
    // Show All button click
    $("#showAllButton").click(() => this.showAllTodos()); 
  }

  // render todo part start
  renderTodos(todos) {
    // if not todod then fetch data from local storage
    if (!todos) {
        todos = JSON.parse(localStorage.getItem(TodoApp.TodoDataKey + this.loggedInEmail)) || [];
    }

    this.todoListElement.empty();
    if (todos.length === 0) {
        this.todoListElement.append("<p>No todos to display.</p>");
    } else {
        $.each(todos, (index, todo) => {
            const todoItem = `
                <div class="card mt-2">
                    <div class="card-body">
                        <h5 class="card-title">${todo.title}</h5>
                        <p class="card-text">${todo.description}</p>
                        <button class="btn btn-warning btn-sm" onclick="todoApp.editTodo(${index})">Edit</button>
                        <button class="btn btn-danger btn-sm" onclick="todoApp.deleteTodo(${index})">Delete</button>
                    </div>
                </div>
            `;
            this.todoListElement.append(todoItem);
        });
    }
}
  // render todo part end


  // add todo part start
  addTodo() {
    const title = this.titleInput.val().trim();
    const description = this.descriptionInput.val().trim();

    if (title && description) {
      let todos = JSON.parse(localStorage.getItem(TodoApp.TodoDataKey + this.loggedInEmail)) || [];

      // Check for duplicate title
      const isDuplicate = todos.some(
        (todo) => todo.title.toLowerCase() === title.toLowerCase()
      );
      if (isDuplicate) {
        alert(
          "this title os aleready exists,please add different ntitle"
        );
        // function stop 
        return;
      }

      // not duplicate then add data to locastorage and display ui using rendor function
      todos.push({ title, description });
      localStorage.setItem(TodoApp.TodoDataKey + this.loggedInEmail,JSON.stringify(todos));

      this.titleInput.val("");
      this.descriptionInput.val("");
      this.renderTodos();
    } else {
      alert("Please enter both title and description.");
    }
  }
  // add todo part end

  // Search todos part start
  searchTodos() {
    const searchQuery = this.searchInput.val().trim().toLowerCase();
    const todos = JSON.parse(localStorage.getItem(TodoApp.TodoDataKey + this.loggedInEmail)) || [];
  
    // Check if search query is empty
    if (searchQuery === "") {
      alert("Please enter a title to search.");
      this.renderTodos(); // Show all todos if search query is empty
      return;
    }
  
    // Filter todos based on search query
    const filteredTodos = todos.filter((todo) => {
      return todo.title.toLowerCase().includes(searchQuery);
    });
  
    // Render filtered todos
    if (filteredTodos.length === 0) {
      alert("No matching todos found.");
    }
    this.renderTodos(filteredTodos);
  }
  // Search todos part end


  // Show all todos part start
  showAllTodos() {
    this.searchInput.val(""); 
    this.renderTodos(); 
  }
  // Show all todos part end

  
  generateTodo() {
    // fun. call through ajax.js 
    fetchRandomTodo(); 
  }


  // Edit a todo part start
  editTodo(index) {
    let todos = JSON.parse(localStorage.getItem(TodoApp.TodoDataKey + this.loggedInEmail));
    const todo = todos[index];

    this.titleInput.val(todo.title);
    this.descriptionInput.val(todo.description);

    // Update on save
    $("#addTodo").off("click").click(() => {
        todo.title = this.titleInput.val().trim();
        todo.description = this.descriptionInput.val().trim();

        todos[index] = todo;
        localStorage.setItem(TodoApp.TodoDataKey + this.loggedInEmail,JSON.stringify(todos));

        this.titleInput.val("");
        this.descriptionInput.val("");
        this.renderTodos();

        // Re-bind addTodo it is use to click edit then save this todo content not add more content
        $("#addTodo").off("click").click(() => this.addTodo());
      });
  }
  // Edit a todo part end

  // delete todo part start
  deleteTodo(index) {
    let todos = JSON.parse(localStorage.getItem(TodoApp.TodoDataKey + this.loggedInEmail));

    // Remove the todo from the list
    // in this case delete count is mendatory because it is delte only one todo
    // if in this case we have not add delete count so then it will delete all todos
    todos.splice(index, 1);
    // remove todo
    localStorage.removeItem(TodoApp.TodoDataKey + this.loggedInEmail);
    // store update todo
    localStorage.setItem(TodoApp.TodoDataKey + this.loggedInEmail, JSON.stringify(todos));
    this.renderTodos();
}
// delete todo part end


  // Logout functionality
  logout() {
    localStorage.removeItem("loggedInEmail");
    window.location.href = "login.html";
  }
}

// Initialize the app
const todoApp = new TodoApp();
