import { authHeader } from "../utils/authHeader"

export default class IncomeService {
    async getAllCategories() {
        const response = await fetch(`/api/income/categories?dateFrom=&dateTo=`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async getAllCategoriesFromRange(dateFrom, dateTo) {
        const response = await fetch(`/api/income/categories?dateFrom=${dateFrom}&dateTo=${dateTo}`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async getCategoryById(id) {
        const response = await fetch(`/api/income/categories/${id}`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async createCategory(name) {
        const response = await fetch(`/api/income/categories`, {
            method: 'POST',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: name
            })
        })
        return await response.json()
    }

    async updateCategory(id, categoryName) {
        const response = await fetch(`/api/income/categories/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: id,
                name: categoryName
            })
        })
        return await response.json()
    }

    async deleteCategory(id) {
        const response = await fetch(`/api/income/categories/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async getIncomesByCategoryId(id) {
        const response = await fetch(`/api/income/${id}`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async getIncomeById(id) {
        const response = await fetch(`/api/income/getById/${id}`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
        return await response.json()
    }

    async createBudgetForCategory(id, amount, date, comment) {
        const response = await fetch(`/api/income`, {
            method: 'POST',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                categoryId: id,
                amount: amount,
                comment: comment,
                date: date
            })
        })
        return await response.json()
    }

    async deleteBudget(id) {
        const response = await fetch(`/api/income/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async updateBudget(id, categoryId, amount, comment, date) {
        const response = await fetch(`/api/income/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: id,
                categoryId: categoryId,
                amount: amount,
                comment: comment,
                date: date
            })
        })
        return await response.json()
    }
}