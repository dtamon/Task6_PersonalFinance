import React, { useState, useEffect } from 'react';
import { useUser } from '../context/UserContext'
import ExpenseService from '../services/ExpenseService';
import IncomeService from '../services/IncomeService';
import { Container, Form, InputGroup, Button } from 'react-bootstrap';
import Chart from '../components/Summary/Chart';

export function Summary() {
    const incomeService = new IncomeService(), expenseService = new ExpenseService()
    const { user } = useUser()
    const [incomeCategories, setIncomeCategories] = useState([])
    const [expenseCategories, setExpenseCategories] = useState([])
    const [dateFrom, setDateFrom] = useState("")
    const [dateTo, setDateTo] = useState("")


    const fetchData = async () => {
        await incomeService.getAllCategoriesFromRange(dateFrom, dateTo)
            .then(data => setIncomeCategories(data))
        await expenseService.getAllCategoriesFromRange(dateFrom, dateTo)
            .then(data => setExpenseCategories(data))
    }

    useEffect(() => {
        fetchData();
    }, [dateFrom, dateTo])

    return (
        <Container className='bg-white'>
            {user !== undefined
                ? <>
                    <div className='d-flex justify-content-center mb-3 row text-center'>
                        <InputGroup className='mt-3' style={{ width: "auto" }}>
                            <InputGroup.Text>Date From</InputGroup.Text>
                            <Form.Control type="date" required onChange={(e) => setDateFrom(e.target.value)} value={dateFrom} />
                            <Button variant='outline-primary' onClick={() => setDateFrom("")}>Clear</Button>
                        </InputGroup>
                        <InputGroup className='mt-3 auto' style={{ width: "auto" }}>
                            <InputGroup.Text>Date From</InputGroup.Text>
                            <Form.Control type="date" required onChange={(e) => setDateTo(e.target.value)} value={dateTo} />
                            <Button variant='outline-primary' onClick={() => setDateTo("")}>Clear</Button>
                        </InputGroup>
                    </div>


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
                </>
                :
                <h3>Sign in or sign up to access app features</h3>
            }
        </Container>
    )
}
