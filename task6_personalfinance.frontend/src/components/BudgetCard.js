import { Button, Card, Stack } from "react-bootstrap";
import { currencyFormatter } from "../utils";
import { useState } from "react";
import AddBudgetModal from "./AddBudgetModal";
import AddCategoryModal from "./AddCategoryModal";
import { GearFill } from "react-bootstrap-icons";

export function BudgetCard({ id, name, sumAmount, type, categories }) {
    const [showAddBudgetModal, setShowAddBudgetModal] = useState(false)
    const [showAddCategoryModal, setShowAddCategoryModal] = useState(false)

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
                        onClick={() => { setShowAddCategoryModal(true) }}
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
            <AddCategoryModal show={showAddCategoryModal} handleClose={() => setShowAddCategoryModal(false)} id={id} name={name} type={type} formMode="edit" />
        </>
    )
}
