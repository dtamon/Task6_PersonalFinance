import { Modal, Table } from 'react-bootstrap'
import React, { useState, useEffect } from 'react'
import ExpenseService from '../../services/ExpenseService'

export default function BudgetListModal(show, handleClose, categoryId, categoryName, type) {
    const expenseService = new ExpenseService()
    const [categoryItems, setCategoryItems] = useState([])

    const fetchData = async () => {
        await expenseService.getExpensesByCategoryId(categoryId)
            .then(data => setCategoryItems(data))
    }

    useEffect(() => {
        fetchData();
    }, [])


    return (
        <Modal show={show} onHide={handleClose} centered>
            <Modal.Header closeButton>
                <Modal.Title>{type}s for {categoryName}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Table striped bordered hover size="sm">
                    {/* <tbody>
                        {categoryItems.map(item => (
                            <tr key={item.id}>
                                <td>{item.amount}</td>
                                <td>{item.comment}</td>
                                <td>{item.date}</td>
                            </tr>
                        ))}
                    </tbody> */}
                </Table>
            </Modal.Body>
        </Modal >
    )
}
