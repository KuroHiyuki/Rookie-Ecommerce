const Logout = () => {
    const handleLogout = () => {
        sessionStorage.removeItem('authToken'); // Thay thế localStorage thành sessionStorage
        window.location.href = '/signin';
    };

    return <button onClick={handleLogout}>Logout</button>;
};

export default Logout;
