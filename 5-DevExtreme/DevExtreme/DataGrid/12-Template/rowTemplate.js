$(document).ready(function () {
    console.log("doc is ready");

    const empData = [
        { id: 1, name: "John Doe", position: "Developer", department: "IT", email: "john@example.com", phone: "123-456-7890", address: "123 Main St, Cityville" },
        { id: 2, name: "Jane Smith", position: "Manager", department: "HR", email: "jane@example.com", phone: "987-654-3210", address: "456 Elm St, Townsville" },
        { id: 3, name: "Mike Johnson", position: "Designer", department: "Marketing", email: "mike@example.com", phone: "555-123-4567", address: "789 Oak St, Village" },
        { id: 4, name: "Sarah Lee", position: "Analyst", department: "Finance", email: "sarah@example.com", phone: "333-444-5555", address: "101 Pine St, Citytown" },
        { id: 5, name: "David Brown", position: "Developer", department: "IT", email: "david@example.com", phone: "777-888-9999", address: "102 Maple St, Towncity" },
        { id: 6, name: "Emily White", position: "HR Specialist", department: "HR", email: "emily@example.com", phone: "555-678-1234", address: "123 Birch St, Villagecity" },
        { id: 7, name: "Chris Black", position: "Project Manager", department: "Operations", email: "chris@example.com", phone: "222-333-4444", address: "456 Cedar St, Cityville" },
        { id: 8, name: "Laura Green", position: "Designer", department: "Marketing", email: "laura@example.com", phone: "111-222-3333", address: "789 Willow St, Townville" },
        { id: 9, name: "Matthew Clark", position: "Software Engineer", department: "IT", email: "matthew@example.com", phone: "444-555-6666", address: "101 Oak St, Citytown" },
        { id: 10, name: "Olivia Harris", position: "HR Manager", department: "HR", email: "olivia@example.com", phone: "555-777-8888", address: "202 Pine St, Cityville" },
        { id: 11, name: "James Turner", position: "Data Scientist", department: "Data Analytics", email: "james@example.com", phone: "888-999-0000", address: "303 Birch St, Towncity" },
        { id: 12, name: "Sophia Young", position: "Marketing Specialist", department: "Marketing", email: "sophia@example.com", phone: "123-987-6543", address: "404 Maple St, Village" },
        { id: 13, name: "Daniel Lee", position: "Consultant", department: "Business", email: "daniel@example.com", phone: "555-333-2222", address: "505 Cedar St, Cityville" },
        { id: 14, name: "Rebecca Scott", position: "Graphic Designer", department: "Design", email: "rebecca@example.com", phone: "777-444-5555", address: "606 Oak St, Townsville" },
        { id: 15, name: "Paul Allen", position: "Full Stack Developer", department: "IT", email: "paul@example.com", phone: "444-888-7777", address: "707 Pine St, Citytown" }
    ];

    $("#rowTempContainer").dxDataGrid({
        dataSource: empData,
        showBorders: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        columnAutoWidth: true,
        columns: [
            {
                dataField: "id",
                caption: "Employee ID",
                dataType: "number"
            },
            {
                dataField: "name",
                dataType: "string",
                caption: "Employee Name"
            },
            {
                dataField: "position",
                dataType: "string",
                caption: "Employee Position"
            },
            {
                dataField: "department",
                dataType: "string",
                caption: "Employee Department"
            }
        ],
        rowTemplate: function (container, options) {
            let customStyle =
                `<tbody class='dx-row' style="background-color: ${options.rowIndex % 2 === 0 ? '#000' : '#fff'}; border-bottom: 1px solid #ddd;">` +
                `<tr style="font-family: Arial, sans-serif; font-size: 14px; color:${options.rowIndex % 2 === 0 ? '#fff' : '#000'}">` +
                `<td style="">${options.values[0]}</td>` +  // Custom padding and alignment for the first column
                `<td style="">${options.values[1]}</td>` +  // Custom padding and alignment for the second column
                `<td style="">${options.values[2]}</td>` +  // Custom padding and alignment for the third column
                `<td style="">${options.values[3]}</td>` +  // Custom padding and alignment for the fourth column
                `</tr>` +
                `<tr style="background-color: #f9f9f9; font-size: 12px;">` +  // Styling for the second row (details, if any)
                `</tr>` +
                `</tbody>`;
            
            container.append(customStyle);
        }
        
    });
});
