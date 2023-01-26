import { Modal, Table, Button } from 'react-bootstrap'
import React, { useState, useEffect } from 'react'
import { currencyFormatter } from '../../utils/formatCurrency'
import ExpenseService from '../../services/ExpenseService'
import IncomeService from '../../services/IncomeService'
import { TrashFill } from 'react-bootstrap-icons'
import EditBudgetModal from './EditBudgetModal'

export default function BudgetHistoryList({ show, handleClose, categoryId, categoryName, type }) {
    const expenseService = new ExpenseService(), incomeService = new IncomeService()
    const income = "Income", expense = "Expense"
    const [categoryItems, setCategoryItems] = useState([])
    const [showEditBudgetModal, setShowEditBudgetModal] = useState(false)
    const [budgetItem, setBudgetItem] = useState({})

    const fetchData = async () => {
        if (type === income) {
            await incomeService.getIncomesByCategoryId(categoryId)
                .then(data => setCategoryItems(data))
        } else if (type === expense) {
            await expenseService.getExpensesByCategoryId(categoryId)
                .then(data => setCategoryItems(data))
        }
    }

    const deleteBudget = async (id) => {
        if (type === income) {
            await incomeService.deleteBudget(id)
        } else if (type === expense) {
            await expenseService.deleteBudget(id)
        }
        fetchData()
    }

    useEffect(() => {
        fetchData();
    }, [show, showEditBudgetModal])


    return (
        <Modal show={show} onHide={handleClose} centered>
            <Modal.Header closeButton>
                <Modal.Title>History for {categoryName}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Amount</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categoryItems.map(item =>
                            <tr key={item.id} onDoubleClick={() => { setShowEditBudgetModal(true); setBudgetItem(item) }}>
                                <td>{currencyFormatter.format(item.amount)}</td>
                                <td className='d-flex justify-content-between'>
                                    <div>
                                        {item.date.split("T")[0]}
                                    </div>
                                    <Button variant='outline-danger' className='me-2'
                                        onClick={() => deleteBudget(item.id)}>
                                        <TrashFill />
                                    </Button></td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Modal.Body>
            {showEditBudgetModal &&
                <EditBudgetModal show={showEditBudgetModal} handleClose={() => setShowEditBudgetModal(false)} {...budgetItem} type={type} />
            }
        </Modal>
    )
}
