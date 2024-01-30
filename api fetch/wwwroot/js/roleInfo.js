const showRoleInfo = async(elems, roleId ) =>{
    elems.$role.hide();
    const response = await fetch(`/Api/RoleId/GetRoleById?roleId=` + roleId);
    if(response.ok){
        const data = await response.json();
        elems.$role.show();
        elems.$id.text(data.id);
        elems.$name.text(data.name);
    }else{
        elems.$role.hide();
    }
}