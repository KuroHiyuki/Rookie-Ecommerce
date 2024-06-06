// src/components/CircularPagination.tsx
import React from "react";
import { useSelector, useDispatch } from 'react-redux';
import { Button, IconButton } from "@material-tailwind/react";
import { ArrowRightIcon, ArrowLeftIcon } from "@heroicons/react/24/outline";
import { RootState, AppDispatch } from '../../Redux/store';
import { getProducts } from '../../Redux/Slice/productSlice';

const CircularPagination: React.FC = () => {
    const dispatch = useDispatch<AppDispatch>();
    const { page, pageSize, totalCount, hasNextPage, hasPreviousPage } = useSelector((state: RootState) => state.products);
    
    const totalPages = Math.ceil(totalCount / pageSize);

    const getItemProps = (index: number) => ({
        variant: page === index ? "filled" : "text",
        color: "gray",
        onClick: () => dispatch(getProducts({ page: index, pageSize })),
        className: "rounded-full",
    });

    const next = () => {
        if (hasNextPage) {
            dispatch(getProducts({ page: page + 1, pageSize }));
        }
    };

    const prev = () => {
        if (hasPreviousPage) {
            dispatch(getProducts({ page: page - 1, pageSize }));
        }
    };

    return (
        <div className="flex items-center gap-4">
            <Button
                variant="text"
                className="flex items-center gap-2 rounded-full"
                onClick={prev}
                disabled={!hasPreviousPage}
            >
                <ArrowLeftIcon strokeWidth={2} className="h-4 w-4" /> Previous
            </Button>
            <div className="flex items-center gap-2">
                {Array.from({ length: totalPages }, (_, i) => i + 1).map((index) => (
                    <IconButton key={index} {...getItemProps(index)}>{index}</IconButton>
                ))}
            </div>
            <Button
                variant="text"
                className="flex items-center gap-2 rounded-full"
                onClick={next}
                disabled={!hasNextPage}
            >
                Next
                <ArrowRightIcon strokeWidth={2} className="h-4 w-4" />
            </Button>
        </div>
    );
};

export default CircularPagination;
