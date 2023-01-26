import { useState, useEffect } from "react"
import { Button, Form, Modal } from "react-bootstrap"
import ExpenseService from "../../services/ExpenseService"
import IncomeService from "../../services/IncomeService"

export default function EditBudgetModal({ show, handleClose, id, categoryId, amount, comment, date, type }) {
    const incomeService = new IncomeService()
    const expenseService = new ExpenseService()
    const [budgetAmount, setAmount] = useState()
    const [budgetDate, setDate] = useState()
    const [budgetComment, setComment] = useState()

    useEffect(() => {
        setAmount(amount);
        setDate(date)
        setComment(comment)
    }, [amount, comment, date])

    const handleSubmit = async (e) => {
        e.preventDefault()
        if (type === "Income") {
            await incomeService.updateBudget(id, categoryId, budgetAmount, budgetComment, budgetDate)
        } else if (type === "Expense") {
            await expenseService.updateBudget(id, categoryId, budgetAmount, budgetComment, budgetDate)
        }
        handleClose()
    }

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title>Edit {type}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Amount</Form.Label>
                        <Form.Control type="number" required min={0} step={0.01} onChange={(e) => setAmount(e.target.value)} value={budgetAmount} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Date</Form.Label>
                        {budgetDate !== undefined &&
                            <Form.Control type="date" required onChange={(e) => setDate(e.target.value)} value={budgetDate.split("T")[0]} />
                        }
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Comment</Form.Label>
                        <Form.Control as="textarea" rows={3} required onChange={(e) => setComment(e.target.value)} value={budgetComment} />
                    </Form.Group>
                </Modal.Body>
                <Modal.Footer>
                    <div className="d-flex justify-content-end">
                        <Button variant="primary" type="submit">
                            Save
                        </Button>
                    </div>
                </Modal.Footer>
            </Form>
        </Modal >
    )
}
