import { Button, Card, Stack } from "react-bootstrap";
import { currencyFormatter } from "../utils";
import { useState } from "react";
import AddBudgetModal from "./AddBudgetModal";

export function BudgetCard({ id, name, sumAmount, type }) {
    const [showAddBudgetModal, setShowAddBudgetModal] = useState(false)

    return (
        <>
            <Card>
                <Card.Body>
                    <Card.Title className="d-flex justify-content-between align-items-baseline fw-normal mb-3">
                        <div className="me-2">{name}</div>
                        <Stack direction="horizontal" gap="2">
                            <Button variant="outline-primary" className="ms-auto"
                                onClick={() => setShowAddBudgetModal({ type: type, id: id, name: name, show: true })}>+</Button>
                            <Button variant="outline-secondary">O</Button>
                            <div className="d-flex align-items-baseline">
                                {currencyFormatter.format(sumAmount)}
                            </div>
                        </Stack>
                    </Card.Title>

                </Card.Body>
            </Card>
            <AddBudgetModal show={showAddBudgetModal} handleClose={() => setShowAddBudgetModal(false)} />
        </>
    )
}
