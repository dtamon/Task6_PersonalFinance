import { authHeader } from "../utils/authHeader"

export default class IncomeService {
    async getAllCategories() {
        const response = await fetch(`/api/income/categories`, {
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

    async getIncomeByCategoryId(id) {
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

    async getIncomeById(id, amount, date, comment) {
        const response = await fetch(`/api/income`, {
            method: 'GET',
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
}