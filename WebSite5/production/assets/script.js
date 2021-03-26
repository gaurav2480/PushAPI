$.ajax({
            type: 'Post',
            url: 'DashboardConfig.aspx/GetDataX',    
            contentType: "application/json; charset=utf-8",
            data: "{'cntType':'asa'}",
            success: function (data) {
                 var s = data.d;
                        // preserve newlines, etc - use valid JSON
                        s = s.replace(/\\n/g, "\\n")  
                                       .replace(/\\'/g, "\\'")
                                       .replace(/\\"/g, '\\"')
                                       .replace(/\\&/g, "\\&")
                                       .replace(/\\r/g, "\\r")
                                       .replace(/\\t/g, "\\t")
                                       .replace(/\\b/g, "\\b")
                                       .replace(/\\f/g, "\\f");
                        // remove non-printable and other non-valid JSON chars
                        s = s.replace(/[\u0000-\u0019]+/g,"");

                        //subJson = JSON.parse(s);
				//tmp = (new Function("return [" + s + "];")())
				callback(s);
             
            }
        });

var users = []
function callback(response) {



  users = (new Function("return [" + response + "];")());
  console.log(users)
  //use return_first variable here

//console.log(users)				

$.each(users, function(i, user) {
  appendToUsrTable(user);
});
}

$("form").submit(function(e) {
  e.preventDefault();
});

$("form#addUser").submit(function() {
  var user = {};
  var type = $('input[name="type"]').val().trim();
  var group = $('input[name="group"]').val().trim();
  var desc = $('input[name="desc"]').val().trim();
  var ori = $('input[name="ori"]').val().trim();
  var set = $('input[name="set"]').val().trim();

  if (type && group && desc && ori && set) {
    $(this).serializeArray().map(function(data) {		  
      user[data.name] = data.value;
    });
	
    // var lastUser = users[Object.keys(users).sort().pop()];
    // user.id = lastUser.id + 1;

    addUser(user);
  } else {
    alert("All fields must have a valid value.");
  }
});

function addUser(user) {
  //users.push(user);
  
  $.ajax({
	  type: 'Post',
		url: 'DashboardConfig.aspx/InsertConfig',    
		contentType: "application/json; charset=utf-8",
		data: JSON.stringify(user),
		success: function (data) {
			console.log(data)			
			appendToUsrTable(user);
			flashMessage("Data Inserted successfully!");
		},
		error: function(data){
			alert("Error Insert Failed Please contact your web master!");
		}
	  
  });		
  
}

function editUser(id) {
  $(function () {
              $('#color-picker-component').colorpicker();
          });		
  users.forEach(function(user, i) {
    if (user.id == id) {
	   var element = `<form id="updateUser" action="">
                    <label for="type">Type</label>
                    <input class="form-control" type="text" name="type" value="${user.type}"/>
                    <label for="group">Group</label>
                    <input class="form-control" type="text" name="group" value="${user.group}"/>
					<label for="group">Desc</label>
                    <input class="form-control" type="text" name="desc" value="${user.desc}"/>
					<label for="group">Orig. Value</label>
                    <input class="form-control" type="text" name="ori" value="${user.ori}"/>
					<label for="group">Set Value</label>`;
		if(user.type == "graph_color"){	
			element = element + `<div id="color-picker-component" class="input-group colorpicker-component">
                    <input class="form-control" type="text" name="set" value="${user.set}"/>
					<span class="input-group-addon"><i></i></span>
					</div> `;
		}else{
			element = element + `<input class="form-control" type="text" name="set" value="${user.set}"/>					
					</div> `;
		}		
				
					
      $(".modal-body").empty().append(element);
		
      $(".modal-footer").empty().append(`
                    <button type="button" type="submit" class="btn btn-primary" onClick="updateUser(${id})">Save changes</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </form>
            `);
    }
  });
}

function deleteUser(id) {    
  var datas = "{id:"+id+"}";
  users.forEach(function(user, i) {
	if (user.id == id) {
		var msg = "Config id "+id+" deleted successfully!";	
		var action = confirm("Are you sure you want to delete config id "+id+" set value "+user.set+"?");
		if (user.id == id && action != false) {
				
		  $.ajax({
				type: 'Post',
				url: 'DashboardConfig.aspx/DeleteConfig',    
				contentType: "application/json; charset=utf-8",
				data: datas,
				success: function (data) {
					users.splice(i, 1);
					  $("#userTable #user-" + user.id).remove();
					  flashMessage(msg);
				},
				error: function(data,e){
					console.log(data);
					console.log(e);
					alert("Error Delete Failed Please contact your web master!");
				}	

		  });	
		  
		}
	}
  });
}

function updateUser(id) {
 		
  var msg = "Config updated successfully!";
  var user = {};
  user.id = id;  
  users.forEach(function(user, i) {
  if (user.id == id) {
	  //user.set = $("#updateUser")
	$("#updateUser").children("input").each(function() {
				var value = $(this).val();
				var attr = $(this).attr("name");
				if (attr == "type") {
				  user.type = value;
				} else if (attr == "group") {
				  user.group = value;
				} else if (attr == "desc") {
				  user.desc = value;				
				} else if (attr == "ori") {
				  user.ori = value;				
				} 
				else if (attr == "set") {
				  user.set = value;
				}
			  });
	if (user.type == "graph_color"){
		
		$("#updateUser>div>input").each(function() {
			var value = $(this).val();
			var attr = $(this).attr("name");
			if (attr == "set") {
			  user.set = value;
			}
		});		
	}		
	var datas = "{id:"+id+",type:'"+user.type+"',group:'"+user.group+"',desc:'"+user.desc+"',valueORI:'"+user.ori+"',value:'"+user.set+"'}";	
	$.ajax({
	  type: 'Post',
		url: 'DashboardConfig.aspx/updateUser',    
		contentType: "application/json; charset=utf-8",
		data: datas,
		success: function (data) {
	  
			
			  users.splice(i, 1);
			  users.splice(user.id - 1, 0, user);
			  $("#userTable #user-" + user.id).children(".userData").each(function() {
				var attr = $(this).attr("name");
				if (attr == "type") {
				  $(this).text(user.type);
				} else if (attr == "group") {
				  $(this).text(user.group);
				} else if (attr == "desc") {
				  $(this).text(user.desc);
				}else if (attr == "ori") {
				  $(this).text(user.ori);
				}else if (attr == "set") {
				  $(this).text(user.set);
				}
			  });
			  $(".modal").modal("toggle");
			  msg = "Config id " + user.id +" "+user.set+ " updated successfully!";
			  flashMessage(msg);
			  // $(".flashMsg").fadeTo(3000, 500).slideUp(500, function() {
				  // $(".flashMsg").slideUp(500);
				// });
			  console.log(data)	
		  },
		error: function(data,e){
			console.log("data");
			console.log(data);
			console.log("error msg e");
			console.log(e);
			$(".modal").modal("toggle");
			alert("Error Update Failed Please contact your web master!");
		}		
	  
	});
  }	
	
    if (user.id == id) {
      
    }
  });
}

function flashMessage(msg) {
  $(".flashMsg").remove();
  $(".row").prepend(`
        <div class="col-sm-12"><div class="flashMsg alert alert-success alert-dismissible fade in" role="alert"> <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button> <strong>${msg}</strong></div></div>
    `);
}

function appendToUsrTable(user) {
  $("#userTable > tbody:last-child").append(`
        <tr id="user-${user.id}">
            <td class="userData" name="type">${user.type}</td>
            '<td class="userData" name="group">${user.group}</td>
			'<td class="userData" name="desc">${user.desc}</td>
			'<td id="tdAge" class="userData" name="ori">${user.ori}</td>
            '<td class="userData" name="set">${user.set}</td>
            
            '<td align="center">
                <button class="btn btn-success form-control" onClick="editUser(${user.id})" data-toggle="modal" data-target="#myModal")">EDIT</button>
            </td>
            <td align="center">
                <button class="btn btn-danger form-control" onClick="deleteUser(${user.id})">DELETE</button>
            </td>
        </tr>
    `);
}
