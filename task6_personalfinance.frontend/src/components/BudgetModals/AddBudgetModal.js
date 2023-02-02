import { useState } from "react"
import { Button, Form, Modal } from "react-bootstrap"
import ExpenseService from "../../services/ExpenseService"
import IncomeService from "../../services/IncomeService"
import { useUser } from "../../context/UserContext"

export default function AddBudgetModal({ show, handleClose, id, name, type }) {
    const { showSuccessToast } = useUser()
    const incomeService = new IncomeService()
    const expenseService = new ExpenseService()
    const [amount, setAmount] = useState()
    const [date, setDate] = useState()
    const [comment, setComment] = useState()

    async function handleSubmit(e) {
        e.preventDefault()
        if (type === "Income") {
            await incomeService.createBudgetForCategory(id, amount, date, comment)
        } else if (type === "Expense") {
            await expenseService.createBudgetForCategory(id, amount, date, comment)
        }
        handleClose()
        showSuccessToast(type + " added successfully")
    }

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title>New {type} for {name}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Amount</Form.Label>
                        <Form.Control type="number" required min={0} step={0.01} onChange={(e) => setAmount(e.target.value)} value={amount} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Date</Form.Label>
                        <Form.Control type="date" required onChange={(e) => setDate(e.target.value)} value={date} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Comment</Form.Label>
                        <Form.Control as="textarea" rows={3} required onChange={(e) => setComment(e.target.value)} value={comment} />
                    </Form.Group>
                </Modal.Body>
                <Modal.Footer>
                    <div className="d-flex justify-content-end">
                        <Button variant="primary" type="submit">
                            Add
                        </Button>
                    </div>
                </Modal.Footer>
            </Form>
        </Modal >
    )
}
