describe("Trainers page", function () {
  it("show trainers page", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      response: "fixture:week",
    });

    cy.visit("trainers");
    cy.get("[data-cy=registrationsChart]").should("be.visible");
    cy.get("[data-cy=trainings]").should("be.visible");
    cy.get("[data-cy=message]").should("not.be.visible");
  });

  it("no trainings for week, show no trainings message", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      response: "fixture:emptyWeek",
    });

    cy.visit("trainers");
    cy.get("[data-cy=registrationsChart]").should("not.exist");
    cy.get("[data-cy=trainings]").should("not.exist");
    cy.get("[data-cy=message]").should("be.visible");
  });

});
