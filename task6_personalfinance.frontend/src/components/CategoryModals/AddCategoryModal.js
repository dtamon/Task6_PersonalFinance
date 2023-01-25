import { Button, Form, Modal } from "react-bootstrap"
import React, { useState } from 'react'
import IncomeService from "../../services/IncomeService"
import ExpenseService from "../../services/ExpenseService"

export default function AddCategoryModal({ show, handleClose, type }) {
    const incomeService = new IncomeService()
    const expenseService = new ExpenseService()
    const income = "Income"
    const expense = "Expense"
    const [categoryName, setCategoryName] = useState()

    function handleSubmit(e) {
        e.preventDefault()
        handleClose()
        createCategory()
        setCategoryName()
    }

    const createCategory = async () => {
        if (type === income) {
            await incomeService.createCategory(categoryName)
        } else if (type === expense) {
            await expenseService.createCategory(categoryName)
        }
    }

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title>New {type} category</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Category Name</Form.Label>
                        <Form.Control type="text" required onChange={(e) => setCategoryName(e.target.value)} value={categoryName} />
                    </Form.Group>
                    <div className="d-flex justify-content-end">
                        <Button variant="primary" type="submit">
                            Save
                        </Button>
                    </div>
                </Modal.Body>
            </Form>
        </Modal>
    )
}
