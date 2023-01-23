import { Button, Form, Modal } from "react-bootstrap"
import React, { useEffect, useState } from 'react'
import IncomeService from "../services/IncomeService"
import ExpenseService from "../services/ExpenseService"

export default function AddCategoryModal({ show, handleClose, id, name, type, formMode }) {
    const incomeService = new IncomeService()
    const expenseService = new ExpenseService()
    const [categoryName, setCategoryName] = useState()

    function handleSubmit(e) {
        e.preventDefault()
        handleClose()
        if (formMode === "add") {
            createCategory()
        } else if (formMode === "edit") {
            updateCategory()
        }
    }

    const createCategory = async () => {
        if (type === "Income") {
            await incomeService.createCategory(categoryName)
        } else if (type === "Expense") {
            await expenseService.createCategory(categoryName)
        }
    }

    const updateCategory = async () => {
        if (type === "Income") {
            await incomeService.updateCategory(id, categoryName)
        } else if (type === "Expense") {
            await expenseService.updateCategory(id, categoryName)
        }
    }

    const deleteCategory = async () => {
        if (type === "Income") {
            await incomeService.deleteCategory(id)
        } else if (type === "Expense") {
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
                    {formMode === "add" ?
                        <Modal.Title>New {type} category</Modal.Title>
                        : <Modal.Title>Edit category</Modal.Title>
                    }
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
                        {formMode === "edit" ?
                            <Button variant="primary" onClick={() => deleteCategory()}>
                                Remove
                            </Button> : <></>
                        }
                    </div>
                </Modal.Body>
            </Form>
        </Modal>
    )
}
