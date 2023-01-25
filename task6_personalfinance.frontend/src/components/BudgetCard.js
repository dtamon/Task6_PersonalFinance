import { Button, Card, Stack } from "react-bootstrap";
import { currencyFormatter } from "../utils/formatCurrency";
import { useEffect, useState } from "react";
import AddBudgetModal from "./BudgetModals/AddBudgetModal";
import { GearFill, TrashFill } from "react-bootstrap-icons";
import EditCategoryModal from "./CategoryModals/EditCategoryModal";
import ExpenseService from "../services/ExpenseService";
import IncomeService from "../services/IncomeService";

export function BudgetCard({ id, type, refresh }) {
    const expenseService = new ExpenseService(), incomeService = new IncomeService()
    const income = "Income", expense = "Expense"
    const [category, setCategory] = useState({})
    const [showAddBudgetModal, setShowAddBudgetModal] = useState(false)
    const [showEditCategoryModal, setShowEditCategoryModal] = useState(false)

    const fetchData = async () => {
        if (type === income) {
            await incomeService.getCategoryById(id)
                .then(data => setCategory(data))
        } else if (type === expense) {
            await expenseService.getCategoryById(id)
                .then(data => setCategory(data))
        }
    }

    useEffect(() => {
        fetchData();
    }, [showAddBudgetModal, showEditCategoryModal])

    const deleteCategory = async () => {
        if (type === income) {
            await incomeService.deleteCategory(id)
        } else if (type === expense) {
            await expenseService.deleteCategory(id)
        }
        refresh(id)
    }

    return (
        <>
            <Card>
                <Card.Body>
                    <Card.Title className="d-flex justify-content-between align-items-baseline fw-normal mb-3">
                        <div className="me-2">{category.name}</div>
                        <Stack direction="horizontal" gap="2">
                            <Button variant="outline-primary" size="sm" className="ms-auto rounded-circle justify-content-center align-items-center"
                                onClick={() => setShowAddBudgetModal(true)}>+</Button>
                            <Button variant="outline-secondary" size="sm" className="rounded-circle justify-content-center align-items-center"
                            // onClick={() => setShowBudgetListModal(true)}
                            >O</Button>
                            <div className="d-flex align-items-baseline">
                                {currencyFormatter.format(category.sumAmount)}
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
            <AddBudgetModal show={showAddBudgetModal} handleClose={() => setShowAddBudgetModal(false)} {...category} type={type} />
            <EditCategoryModal show={showEditCategoryModal} handleClose={() => { setShowEditCategoryModal(false); }} onDelete={(id) => { setShowEditCategoryModal(); deleteCategory(id) }} {...category} type={type} />
        </>
    )
}
