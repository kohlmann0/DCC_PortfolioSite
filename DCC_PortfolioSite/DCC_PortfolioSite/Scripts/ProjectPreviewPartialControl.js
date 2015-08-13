$(document).ready(function () {
    $(document).on('input propertychange paste', function () {
        $("#previewProjectName").html($("#ProjectName").val());
        $("#previewTechnologies").html($("#Technologies").val());
        $("#previewTeamMembers").html($("#TeamMembers").val());
        $("#previewDevelopmentTime").html($("#DevelopmentTime").val());
        $("#previewProjectDescription").html($("#ProjectDescription").val());
        $("#previewRepoLink").html($("#RepoLink").val());

    })
});