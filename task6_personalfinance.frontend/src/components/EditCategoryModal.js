import { Button, Form, Modal } from "react-bootstrap"
import React, { useEffect, useState } from 'react'
import IncomeService from "../services/IncomeService"
import ExpenseService from "../services/ExpenseService"

export default function EditCategoryModal({ show, handleClose, id, name, type }) {
    const incomeService = new IncomeService()
    const expenseService = new ExpenseService()
    const income = "Income"
    const expense = "Expense"
    const [categoryName, setCategoryName] = useState()

    function handleSubmit(e) {
        e.preventDefault()
        handleClose()
        updateCategory()
    }

    const updateCategory = async () => {
        if (type === income) {
            await incomeService.updateCategory(id, categoryName)
        } else if (type === expense) {
            await expenseService.updateCategory(id, categoryName)
        }
    }

    const deleteCategory = async () => {
        handleClose()
        if (type === income) {
            await incomeService.deleteCategory(id)
        } else if (type === expense) {
            await expenseService.deleteCategory(id)
        }

    }

    useEffect(() => {
        setCategoryName(name)
    }, [])

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title>Edit category</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Category Name</Form.Label>
                        <Form.Control type="text" required onChange={(e) => setCategoryName(e.target.value)} value={categoryName} />
                    </Form.Group>
                    <div className="d-flex justify-content-end">
                        <Button variant="primary me-1" type="submit">
                            Save
                        </Button>
                        <Button variant="primary" onClick={() => deleteCategory()}>
                            Remove
                        </Button>
                    </div>
                </Modal.Body>
            </Form>
        </Modal>
    )
}
