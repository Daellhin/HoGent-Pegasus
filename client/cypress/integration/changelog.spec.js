describe("Changelog page", function () {
  it("show changelog page", function () {
    cy.visit("changelog");
    cy.get("[data-cy=changelog]").children().should('have.length.greaterThan',0);
    cy.get("[data-cy=error]").should("not.exist");
  });
});
