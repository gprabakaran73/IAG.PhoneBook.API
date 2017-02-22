angular.module('moodDashboard')
    .controller('moodBarChartctrl', ['$scope','MoodDataFactory',
        function ($scope, MoodDataFactory) {

            window.chartColors = {
                red: 'rgb(255, 99, 132)',
                orange: 'rgb(255, 159, 64)',
                yellow: 'rgb(255, 205, 86)',
                green: 'rgb(75, 192, 192)',
                blue: 'rgb(54, 162, 235)',
                purple: 'rgb(153, 102, 255)',
                grey: 'rgb(231,233,237)',
                lightyello: 'rgb(229, 178, 25)'
            };

            var mgrid = '58257';//31434'40537 58257';
            var groups = [];
            var barGroups = [];
            var totalMood = [];

            var avgMood = 0;
            var excellentTotal = 0;
            var goodTotal = 0;
            var discouragedTotal = 0;
            var disencagedTotal = 0;
            var okayTotal = 0;

            var teamNames;
            var disencagedCountForTeam;
            var discouragedCountForTeam;
            var okayCountForTeam;
            var goodCountForTeam;
            var excellentCountForTeam;
            var avgCountForTeam
            var datesForChart;
            var pieChartData;


            function getTeamNames(item, index) { return item.TeamName; }
            function getDisencagedTeamCount(item, index) { return item.disencaged; }
            function getDiscouragedTeamCount(item, index) { return item.discouraged; }
            function getOkayTeamCount(item, index) { return item.okay; }
            function getGoodTeamCount(item, index) { return item.good; }
            function getExcellentTeamCount(item, index) { return item.excellent };
            function getCreatedDates(item, index) { return item.date; }
            function getAverageCount(item, index) {
                return Math.round((item.disencaged * 1 + item.discouraged * 2 + item.okay * 3 + item.good * 4 + item.excellent * 5) / (item.disencaged + item.discouraged + item.okay + item.good + item.excellent))
            }
            
            function add(teamName, e, dte) {
                var found = groups.some(function (el) {
                    if (el.date === dte) {
                        switch (e) {
                            case 1: el.disencaged++; break;
                            case 2: el.discouraged++; break;
                            case 3: el.okay++; break;
                            case 4: el.good++; break;
                            case 5: el.excellent++; break;
                        }
                        return true;
                    }
                    else {
                        return false;
                    }
                });
                if (!found) {
                    if (teamName != 'null') {
                        groups.push({ TeamName: teamName, excellent: 0, good: 0, discouraged: 0, disencaged: 0, okay: 0, date: dte });                       
                    }
                }
            }

            function addbar(teamName, e, dte) {
                var foundforbar = barGroups.some(function (el) {
                    if (el.TeamName === teamName) {
                        switch (e) {
                            case 1: el.disencaged++; break;
                            case 2: el.discouraged++; break;
                            case 3: el.okay++; break;
                            case 4: el.good++; break;
                            case 5: el.excellent++; break;
                        }
                        return true;
                    }
                    else {
                        return false;
                    }
                });
                if (!foundforbar) {
                    if (teamName != 'null') {
                        barGroups.push({ TeamName: teamName, excellent: 0, good: 0, discouraged: 0, disencaged: 0, okay: 0, date: dte });
                    }
                }
            }

            MoodDataFactory.getTeamByManagerId(mgrid).then(function (data) {
                if (!data.length == 0) {
                    $.each(data, function (i, obj) {
                        lvl = obj.level;
                        switch (parseInt(lvl - 1)) {
                            case 0: {
                                add(obj.teamleavel0, obj.Rating, obj.Okay, obj.CreatedDate);
                                addbar(obj.teamleavel0, obj.Rating, obj.CreatedDate);
                                break;
                            }
                            case 1: {
                                add(obj.teamleavel1, obj.Rating, obj.CreatedDate);
                                addbar(obj.teamleavel1, obj.Rating, obj.CreatedDate);
                                break;
                            }
                            case 2: {
                                add(obj.teamleavel2, obj.Rating, obj.CreatedDate);
                                addbar(obj.teamleavel2, obj.Rating, obj.CreatedDate);
                                break;
                                break;
                            }
                            case 3: {
                                add(obj.teamleavel3, obj.Rating, obj.CreatedDate);
                                addbar(obj.teamleavel3, obj.Rating, obj.CreatedDate);
                                break;
                            }
                        }

                        switch (obj.Rating) {
                            case 1: disencagedTotal++; break;
                            case 2: discouragedTotal++; break;
                            case 3: okayTotal++; break;
                            case 4: goodTotal++; break;
                            case 5: excellentTotal++; break;
                        }

                    });

                    teamNames = barGroups.map(getTeamNames);
                    disencagedCountForTeam = barGroups.map(getDisencagedTeamCount);
                    discouragedCountForTeam = barGroups.map(getDiscouragedTeamCount);
                    okayCountForTeam = barGroups.map(getOkayTeamCount);
                    goodCountForTeam = barGroups.map(getGoodTeamCount);
                    excellentCountForTeam = barGroups.map(getExcellentTeamCount);
                    pieChartData = [excellentTotal, goodTotal, okayTotal, discouragedTotal, disencagedTotal];
                    averageCountForTeam = groups.map(getAverageCount);;
                    datesForChart = groups.map(getCreatedDates);
                }
                else {
                    alert('error')
                }
                loadBarChart();
                loadPieChart();
                loadAvgChart();
                //loadChangeChart();
            });
            
            function loadBarChart() {
                $scope.barChartData = {
                    labels: teamNames,
                    datasets: [{
                        label: 'Excellent',
                        backgroundColor: window.chartColors.green,
                        borderColor: window.chartColors.green,
                        data: excellentCountForTeam
                    }, {
                        label: 'Good',
                        backgroundColor: window.chartColors.blue,
                        borderColor: window.chartColors.blue,
                        data: goodCountForTeam
                    }, {
                        label: 'Okay',
                        backgroundColor: window.chartColors.yellow,
                        borderColor: window.chartColors.yellow,
                        data: okayCountForTeam
                    }, {
                        label: 'Discouraged',
                        backgroundColor: window.chartColors.orange,
                        borderColor: window.chartColors.orange,
                        data: discouragedCountForTeam
                    }, {
                        label: 'Disengaged',
                        backgroundColor: window.chartColors.red,
                        borderColor: window.chartColors.red,
                        data: disencagedCountForTeam
                    }]
                };

                $scope.barChartOptions = {
                    responsive: true,
                    maintainAspectRatio: true,
                    animation: {
                        duration: 10,
                    },
                    tooltips: {
                        mode: 'label',
                        callbacks: {
                            label: function (tooltipItem, data) {
                                return data.datasets[tooltipItem.datasetIndex].label + ": " + tooltipItem.yLabel;
                            }
                        }
                    },
                    scales: {
                        xAxes: [{
                            stacked: true,
                            gridLines: { display: false },
                        }],
                        yAxes: [{
                            stacked: true,

                        }],
                    }, // scales
                    legend: { display: true }
                };

                $scope.onBarChartClick = function (event) {
                    console.log('BarController', 'onBarChartClick', event);
                }
            }

            function loadPieChart() {
                $scope.pieChartData = {
                    labels: [
                        "Excellent",
                        "Good",
                        "Okay",
                        "Discouraged",
                        "Disengaged"
                    ],
                    datasets: [
                      {
                          data: pieChartData,
                          backgroundColor: [
					            window.chartColors.green,
					            window.chartColors.blue,
					            window.chartColors.yellow,
					            window.chartColors.orange,
					            window.chartColors.red
                          ],
                          hoverBackgroundColor: [
                            "#FF6384",
                            "#36A2EB",
                            "#FFCE56",
                            "#RECE56",
                            "#GGCE56",
                          ]
                      }
                    ]
                };

                $scope.pieChartOptions = { responsive: true, maintainAspectRatio: true };

                $scope.onPieChartClick = function (event) {
                    console.log('PieDoughnutController', 'onPieChartClick', event);
                }
            }

            function loadAvgChart() {
                $scope.avgChartData = {
                    labels: datesForChart,//['21/12/2016', '21/1/2017'],//,
                    datasets: [{
                        label: 'Average',
                        backgroundColor: window.chartColors.lightyello,
                        borderColor: window.chartColors.yellow,
                        data: averageCountForTeam,//[2, 2]//averageCountForTeam
                    }]
                };

                $scope.avgChartOptions = {
                    responsive: true,
                    //title: {display: true, text: 'Average Aura'},
                    scales: {
                        yAxes: [{
                            display: true,
                            ticks: {
                                suggestedMin: 0,
                                suggestedMax: 5,
                                stepSize: 1
                            }
                        }]
                    }
                };

                $scope.onAvgChartClick = function (event) {
                    console.log('AvgController', 'onAvgChartClick', event);
                }
            }
            
}]);
