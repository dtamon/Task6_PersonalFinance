import { Button, Form, Modal } from "react-bootstrap"
import React, { useEffect, useState } from 'react'
import IncomeService from "../../services/IncomeService"
import ExpenseService from "../../services/ExpenseService"
import { useUser } from "../../context/UserContext"

export default function EditCategoryModal({ show, handleClose, id, name, type, onDelete }) {
    const { showSuccessToast } = useUser()
    const expenseService = new ExpenseService(), incomeService = new IncomeService()
    const income = "Income", expense = "Expense"
    const [categoryName, setCategoryName] = useState()

    useEffect(() => {
        setCategoryName(name);
    }, [name])

    async function handleSubmit(e) {
        e.preventDefault()
        await updateCategory()
        handleClose()
    }

    const updateCategory = async () => {
        if (type === income) {
            await incomeService.updateCategory(id, categoryName)
        } else if (type === expense) {
            await expenseService.updateCategory(id, categoryName)
        }
        showSuccessToast(type + " category updated successfully")
    }

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
                </Modal.Body>
                <Modal.Footer>
                    <div className="d-flex justify-content-end">
                        <Button variant="primary me-2" type="submit">
                            Save
                        </Button>
                        <Button variant="primary" onClick={() => onDelete(id)}>
                            Remove
                        </Button>
                    </div>
                </Modal.Footer>
            </Form>
        </Modal>
    )
}
