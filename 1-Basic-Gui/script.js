$(document).ready(function() {
    // Load students from localStorage when page is loaded
    loadStudents();

    // Add student data
    $('#studentForm').submit(function(e) {
        e.preventDefault();

        const name = $('#name').val();
        const rollNumber = $('#rollNumber').val();
        const course = $('#course').val();

        // Create new student object
        const newStudent = { name, rollNumber, course };

        // Get existing students from localStorage or initialize as empty array
        let students = JSON.parse(localStorage.getItem('students')) || [];

        // Add new student to the array
        students.push(newStudent);

        // Save updated students array to localStorage
        localStorage.setItem('students', JSON.stringify(students));

        // Refresh the student list
        loadStudents();

        // Clear form fields
        $('#studentForm')[0].reset();
    });

    // Function to load students from localStorage and display them
    function loadStudents() {
        // Get students from localStorage
        const students = JSON.parse(localStorage.getItem('students')) || [];

        // Clear the current list
        $('#studentList').empty();

        // Add each student to the list
        students.forEach(function(student, index) {
            $('#studentList').append(`
                <li class="list-group-item">
                    ${student.name} (Roll No: ${student.rollNumber}) - ${student.course}
                    <button class="btn btn-warning btn-sm float-end mx-2 editBtn" data-id="${index}">Edit</button>
                    <button class="btn btn-danger btn-sm float-end deleteBtn" data-id="${index}">Delete</button>
                </li>
            `);
        });
    }

    // Delete student data
    $(document).on('click', '.deleteBtn', function() {
        const studentId = $(this).data('id');

        // Get existing students from localStorage
        let students = JSON.parse(localStorage.getItem('students'));

        // Remove the student from the array
        students.splice(studentId, 1);

        // Save the updated students array back to localStorage
        localStorage.setItem('students', JSON.stringify(students));

        // Refresh the student list
        loadStudents();
    });

    // Edit student data
    $(document).on('click', '.editBtn', function() {
        const studentId = $(this).data('id');
        let students = JSON.parse(localStorage.getItem('students'));
        const student = students[studentId];

        // Pre-fill the form with student's current data
        $('#name').val(student.name);
        $('#rollNumber').val(student.rollNumber);
        $('#course').val(student.course);

        // Change the form button to "Update"
        $('#studentForm').off('submit').on('submit', function(e) {
            e.preventDefault();

            student.name = $('#name').val();
            student.rollNumber = $('#rollNumber').val();
            student.course = $('#course').val();

            // Save updated student data in localStorage
            students[studentId] = student;
            localStorage.setItem('students', JSON.stringify(students));

            // Refresh the student list
            loadStudents();

            // Clear form and change button back to "Add Student"
            $('#studentForm')[0].reset();
            $('#studentForm').off('submit').on('submit', function(e) {
                e.preventDefault();
                // Existing logic for adding new student
            });
        });
    });
});
