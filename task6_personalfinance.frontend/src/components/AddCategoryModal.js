import { Button, Form, Modal } from "react-bootstrap"
import React, { useState } from 'react'
import IncomeService from "../services/IncomeService"

export default function AddCategoryModal({ show, handleClose }) {
    const incomeService = new IncomeService()
    const [categoryName, setCategoryName] = useState()

    const handleSubmit = async (e) => {
        e.preventDefault()
        handleClose()
        await incomeService.createCategory(categoryName)
    }

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title>New Category</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Category Name</Form.Label>
                        <Form.Control type="text" required onChange={(e) => setCategoryName(e.target.value)} value={categoryName} />
                    </Form.Group>
                    <div className="d-flex justify-content-end">
                        <Button variant="primary" type="submit">
                            Add Category
                        </Button>
                    </div>
                </Modal.Body>
            </Form>
        </Modal>
    )
}
