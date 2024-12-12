class TodoApp {
  static USER_KEY_PREFIX = "user_"; // Static prefix for user data
  static TODO_KEY_PREFIX = "todos_"; // Static prefix for todos

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

      window.location.href = "login.htm";
      // redirectTo("index.htm")
    } else {
      // get todo data if user is alerady login
      const userData = JSON.parse(
        localStorage.getItem(TodoApp.USER_KEY_PREFIX + this.loggedInEmail)
      );
      this.usernameElement.text(userData.firstName + " " + userData.lastName);
    }
  }

  // all event haldlers based on todo functionality 
  initEventHandlers() {
    // all function call with click event is call call back function
    $("#addTodo").click(() => this.addTodo());
    $("#generateTodos").click(() => this.generateTodo());
    $("#logout").click(() => this.logout());
    $("#searchButton").click(() => this.searchTodos()); // Search button click
    $("#showAllButton").click(() => this.showAllTodos()); // Show All button click
  }

  // render todo part start
  renderTodos(todos) {
    // Agar todos argument pass nahi hota, toh localStorage se fetch karo
    if (!todos) {
        todos = JSON.parse(localStorage.getItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail)) || [];
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
      let todos = JSON.parse(localStorage.getItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail)) || [];

      // Check for duplicate title
      const isDuplicate = todos.some(
        (todo) => todo.title.toLowerCase() === title.toLowerCase()
      );
      if (isDuplicate) {
        alert(
          "A todo with this title already exists. Please use a different title."
        );
        // function stop 
        return;
      }

      // not duplicate then add data to locastorage and display ui using rendor function
      todos.push({ title, description });
      localStorage.setItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail,JSON.stringify(todos));

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
    const todos =
      JSON.parse(
        localStorage.getItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail)
      ) || [];

    //  jQuery $.grep for filtering
    // includes is use to serchquery exists in title matching
    const filteredTodos = $.grep(todos, function(todo) {
      return todo.title.toLowerCase().includes(searchQuery);
    });

    if (searchQuery === "") {
      alert("Please enter a title to search.");
      //  function stop
      return;
    }

    this.renderTodos(filteredTodos);
}
// Search todos part end


  // Show all todos
  showAllTodos() {
    this.searchInput.val(""); 
    this.renderTodos(); 
  }

  // rendom api using json place holder
  generateTodo() {
    // fun. call through ajax.js 
    fetchRandomTodo(); 
  }

  // Edit a todo part start
  editTodo(index) {
    let todos = JSON.parse(localStorage.getItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail));
    const todo = todos[index];

    this.titleInput.val(todo.title);
    this.descriptionInput.val(todo.description);

    // Update on save
    $("#addTodo").off("click").click(() => {
        todo.title = this.titleInput.val().trim();
        todo.description = this.descriptionInput.val().trim();

        todos[index] = todo;
        localStorage.setItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail,JSON.stringify(todos));

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
    let todos = JSON.parse(localStorage.getItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail));

    // Remove the todo from the list
    todos.splice(index, 1);
    // remove todo
    localStorage.removeItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail);
    // store update todo
    localStorage.setItem(TodoApp.TODO_KEY_PREFIX + this.loggedInEmail, JSON.stringify(todos));
    this.renderTodos();
}
// delete todo part end


  // Logout functionality
  logout() {
    localStorage.removeItem("loggedInEmail");
    window.location.href = "login.htm";
  }
}

// Initialize the app
const todoApp = new TodoApp();
