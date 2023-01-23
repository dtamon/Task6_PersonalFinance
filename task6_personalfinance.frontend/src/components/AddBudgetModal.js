import { Button, Form, Modal } from "react-bootstrap"

export default function AddBudgetModal({ type, id, categoryName, show, handleClose }) {
    function handleSubmit(e) { }

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title>New {type}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Amount</Form.Label>
                        <Form.Control type="number" required min={0} step={0.01} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Comment</Form.Label>
                        <Form.Control as="textarea" rows={3} required />
                    </Form.Group>
                    <div className="d-flex justify-content-end">
                        <Button variant="primary" type="submit">
                            Add
                        </Button>
                    </div>
                </Modal.Body>
            </Form>
        </Modal>
    )
}
