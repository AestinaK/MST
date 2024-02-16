const income = document.getElementById('incomeChart').getContext('2d');
const expenses = document.getElementById('expensesChart').getContext('2d');

fetch('/Api/IncomeExpenses/GetIncomeByCategory')
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        const labels = data.map(i => i.name);
        const amount = data.map(i => i.amount);

        pieChart1.data.labels = labels;
        pieChart1.data.datasets[0].data = amount;
        pieChart1.update();
    })
    .catch(error => {
        console.error('Error fetching data:', error);
    });
const pieChart1 = new Chart(income, {
    type: 'pie',
    data: {
        labels: [],
        datasets: [{
            label: 'Income by category',
            data: [],
            backgroundColor: [
                'rgba(54, 162, 235, 0.5)',
                'rgba(255, 99, 132, 0.5)',
                'rgba(87,213,132,0.5)',
                'rgba(124,58,222,0.5)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)',
                'rgba(255, 99, 132, 1)',
            ],
            borderWidth: 1
        }]
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        legend : {
            position : 'left'
        }
    }
});


fetch('/Api/IncomeExpenses/GetExpensesByCategory')
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        const labels = data.map(i => i.name);
        const amount = data.map(i => i.amount);

        pieChart2.data.labels = labels;
        pieChart2.data.datasets[0].data = amount;
        pieChart2.update();
    })
    .catch(error => {
        console.error('Error fetching data:', error);
    });
const pieChart2 = new Chart(expenses,{
    type:'pie',
    data :{
        labels: [],
        datasets: [{
            label: 'Expenses by category',
            data: [],
            backgroundColor: [
                'rgba(54, 162, 235, 0.5)',
                'rgba(255, 99, 132, 0.5)',
                'rgba(87,213,132,0.5)',
                'rgba(124,58,222,0.5)',
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)',
                'rgba(255, 99, 132, 1)',
            ],
            borderWidth: 1
        }]
    },
    options:{
        responsive: true,
        maintainAspectRatio : false,
        legend : {
            position : 'left'
        }
    }
});
 