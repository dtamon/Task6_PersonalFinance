import React, { useState, useEffect } from 'react';
import { useUser } from '../context/UserContext'
import ExpenseService from '../services/ExpenseService';
import IncomeService from '../services/IncomeService';
import { Container } from 'react-bootstrap';
import Chart from '../components/Summary/Chart';

export function Summary() {
    const incomeService = new IncomeService(), expenseService = new ExpenseService()
    const { user } = useUser()
    const [incomeCategories, setIncomeCategories] = useState([])
    const [expenseCategories, setExpenseCategories] = useState([])
    const [dateRange, setDateRage] = useState(["", ""])


    const fetchData = async () => {
        await incomeService.getAllCategories()
            .then(data => setIncomeCategories(data))
        await expenseService.getAllCategories()
            .then(data => setExpenseCategories(data))
    }

    useEffect(() => {
        fetchData();
    }, [dateRange])

    return (
        <Container className='bg-white'>
            {user !== undefined
                ?
                <div className="d-flex align-items-baseline justify-content-between fw-normal mb-3">
                    <div>
                        <div className='fs-2 text-center'><b>Incomes</b></div>
                        <hr />
                        <Chart categories={incomeCategories} />
                    </div>
                    <div>
                        <div className='fs-1 text-center'><b>Expenses</b></div>
                        <hr />
                        <Chart categories={expenseCategories} />
                    </div>
                </div>
                :
                <h3>Sign in or sign up to access app features</h3>
            }
        </Container>
    )
}
