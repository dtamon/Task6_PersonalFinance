import { Button, Card, Stack } from "react-bootstrap";
import { currencyFormatter } from "../utils";
import { useEffect, useState } from "react";
import AddBudgetModal from "./AddBudgetModal";
import { GearFill } from "react-bootstrap-icons";
import EditCategoryModal from "./EditCategoryModal";

export function BudgetCard({ id, name, sumAmount, handleClose, type, categories }) {
    const [showAddBudgetModal, setShowAddBudgetModal] = useState(false)
    const [showEditCategoryModal, setShowEditCategoryModal] = useState(false)

    useEffect(() => {
        handleClose()
    }, [showEditCategoryModal])

    return (
        <>
            <Card>
                <Card.Body>
                    <Card.Title className="d-flex justify-content-between align-items-baseline fw-normal mb-3">
                        <div className="me-2">{name}</div>
                        <Stack direction="horizontal" gap="2">
                            <Button variant="outline-primary" size="sm" className="ms-auto rounded-circle justify-content-center align-items-center"
                                onClick={() => setShowAddBudgetModal(true)}>+</Button>
                            <Button variant="outline-secondary" size="sm" className="rounded-circle justify-content-center align-items-center"
                            >O</Button>
                            <div className="d-flex align-items-baseline">
                                {currencyFormatter.format(sumAmount)}
                            </div>
                        </Stack>
                    </Card.Title>
                    <div className="rounded-circle justify-content-center align-items-center"
                        onClick={() => { setShowEditCategoryModal(true) }}
                        style={{
                            color: "grey",
                            width: ".5rem",
                            height: ".01rem",
                            bottom: 0,
                            right: 0,
                            transform: "translate(-300%, -46000%)",
                        }}
                    ><GearFill /></div>
                </Card.Body>
            </Card>
            <AddBudgetModal show={showAddBudgetModal} handleClose={() => setShowAddBudgetModal(false)} categoryId={id} categoryName={name} type={type} categories={categories} />
            <EditCategoryModal show={showEditCategoryModal} handleClose={() => setShowEditCategoryModal(false)} id={id} name={name} type="Expense" />
        </>
    )
}
