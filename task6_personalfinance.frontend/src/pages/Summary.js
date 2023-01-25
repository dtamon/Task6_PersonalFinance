import React, { useState } from 'react';
import { Chart } from 'primereact/chart';
import { useUser } from '../context/UserContext'
import ExpenseService from '../services/ExpenseService';
import IncomeService from '../services/IncomeService';

export function Summary() {
    const incomeService = new IncomeService, expenseService = new ExpenseService
    const { user } = useUser()
    const [incomeChartData] = useState({
        labels: ['A', 'B', 'C'],
        datasets: [
            {
                data: [300, 50, 100],
                backgroundColor: [
                    "#42A5F5",
                    "#66BB6A",
                    "#FFA726"
                ],
                hoverBackgroundColor: [
                    "#64B5F6",
                    "#81C784",
                    "#FFB74D"
                ],
            }
        ],
    });
    const [incomeLightOptions] = useState({
        plugins: {
            legend: {
                labels: {
                    color: '#495057'
                }
            }
        }
    });
    const [expenseChartData] = useState({
        labels: ['D', 'E'],
        datasets: [
            {
                data: [50, 100],
                backgroundColor: [
                    "#42A5F5",
                    "#66BB6A",
                ],
                hoverBackgroundColor: [
                    "#64B5F6",
                    "#81C784",
                ],
            }
        ],
    });

    const [expenseLightOptions] = useState({
        plugins: {
            legend: {
                labels: {
                    color: '#495057'
                }
            }
        }
    });

    return (
        <>
            {user !== undefined
                ? <>
                    <div className="d-flex align-items-baseline fw-normal mb-3">
                        <Chart type="pie" data={incomeChartData} options={incomeLightOptions} style={{ position: 'relative', width: '40%' }} />
                        <div className='ms-5'>
                            <h3>blebleble</h3>
                            <h3>blebleble</h3>
                            <h3>blebleble</h3>
                            <h3>blebleble</h3>
                        </div>
                    </div>
                    <div>
                        <Chart type="pie" data={expenseChartData} options={expenseLightOptions} style={{ position: 'relative', width: '40%' }} />
                    </div>
                    <div className="d-flex align-items-baseline fw-normal mb-3">
                        <Chart type="pie" data={incomeChartData} options={incomeLightOptions} style={{ position: 'relative', width: '40%' }} />
                        <div className='ms-5'>
                            <h3>blebleble</h3>
                            <h3>blebleble</h3>
                            <h3>blebleble</h3>
                            <h3>blebleble</h3>
                        </div>
                    </div>
                    <div>
                        <Chart type="pie" data={expenseChartData} options={expenseLightOptions} style={{ position: 'relative', width: '40%' }} />
                    </div>
                </>
                :
                <h3>Sign in or sign up to access app features</h3>
            }
        </>
    )
}
