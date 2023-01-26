import React, { useState, useEffect } from 'react'
import { currencyFormatter } from '../../utils/formatCurrency'
import { Chart as PrChart } from 'primereact/chart'


export default function Chart({ categories }) {
    const [categoryLabels, setCategoryLabels] = useState([])
    const [categoryData, setCategoryData] = useState([])

    useEffect(() => {
        categories.map(category => {
            categoryLabels.push(category.name)
            categoryData.push(category.sumAmount)
        })
    }, [categories])

    const [chartData] = useState({
        labels: categoryLabels,
        datasets: [
            {
                data: categoryData,
                backgroundColor: [
                    "#42A5F5",
                    "#66BB6A",
                    "#FFA726",
                    "#3c702a"
                ],
                hoverBackgroundColor: [
                    "#64B5F6",
                    "#81C784",
                    "#FFB74D",
                    "#496e3b"
                ],
            }
        ],
    });
    const [lightOptions] = useState({
        plugins: {
            legend: {
                labels: {
                    color: '#495057'
                }
            }
        }
    });

    return (
        <div>
            {chartData !== undefined &&
                <>
                    <PrChart type="pie" data={chartData} options={lightOptions} style={{ position: 'relative', width: '130%' }} />
                    <hr />
                    <div className='ms-5'>
                        {categories.map(category =>
                            <div className='d-flex justify-content-between'>
                                <div className='fs-4'>{category.name}:</div>
                                <div className='fs-4'>{currencyFormatter.format(category.sumAmount)}</div>
                            </div>
                        )}
                    </div>
                </>
            }
        </div >
    )
}
